import { DatePipe } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { MatMenuTrigger } from '@angular/material/menu';
import { Chat } from 'src/models/chat';
import { Message } from 'src/models/message';
import { AuthorizationService } from 'src/services/authorization-service/authorization-service';
import { RoomService } from 'src/services/room-service/room-service';


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  title = 'chat-ui';
  text: string = "";
  message: Message = new Message();
  page: number | null = null;
  chatId: number = -1;
  selectedMessage!: Message;
  chatType: number = 0;
  isMessageEditing: Boolean = false;
  isMessageReplying: Boolean = false;
  isMessageReplyingOnlyForUser: Boolean = false;
  userId: number = Number.parseInt(localStorage.getItem("userId") ?? "-1"); 
  openMenu: boolean = false;
  trigger: any;
  
  @HostListener('document:click', ['$event'])
    documentClick(event: MouseEvent) {
        this.openMenu = false;
    }

  constructor(public roomService: RoomService, 
    private authorizationService: AuthorizationService) {
    this.roomService.notify.subscribe(() => {this.getMessages(this.chatId);});
  }

  ngOnInit(): void {
    this.roomService.connect();
  }

  sendMessage(): void {
    this.message.messageText = this.text;
    this.message.userId = this.userId;
    this.message.chatId = this.chatId;
    this.message.userName = localStorage.getItem("userName");
    if(this.isMessageReplying){
      this.message.repliedMessageId = this.selectedMessage.id;
      this.message.repliedMessage = this.selectedMessage;
      if(this.isMessageReplyingOnlyForUser){this.message.receiverId = this.selectedMessage.userId;}
    }

    if(!this.isMessageEditing){
      this.roomService.sendMessage(this.message).subscribe({
        next: _ => {this.text = ''; this.message = new Message(); this.isMessageReplying = false; this.isMessageReplyingOnlyForUser = false;},
        error: (err) => console.error(err)
      });
    }
    else{
      this.selectedMessage.messageText = this.text;
      this.roomService.updateMessage(this.selectedMessage).subscribe({
        next: _ => {this.text = ''; this.message = new Message(); this.isMessageEditing = false;},
        error: (err) => console.error(err)
      });
    }
  }

  getMessages(chatId: number)
  {
    this.roomService.getMessages(chatId, this.page).subscribe(pageInfo => 
      {
        this.roomService.messageService.messages = pageInfo.messages;
        this.page = pageInfo.currentPageNumber;
      });
  }

  getchatName(chat: Chat){
    if(chat.chatType == 1){
      for(let user of chat.users){
        if(user.id != this.userId){
          return user.userName;
        }
      }
     }
     return chat.name;
  }

  joinRoom(newChat: Chat){
    if(this.chatId != -1){this.roomService.leaveRoom(this.chatId); this.roomService.messageService.messages = []}
    this.roomService.joinRoom(newChat.id ?? -1).subscribe({
      next: _ => {this.chatId = newChat.id ?? -1; this.page = null; this.getMessages(newChat.id ?? -1); this.chatType = newChat.chatType},
      error: (err) => console.error(err)
    });
  }

  previousPage(){
    if(this.page!=null){this.page--;} 
    this.getMessages(this.chatId);
  }

  nextPage(){
    if(this.page!=null){this.page++;} 
    this.getMessages(this.chatId);
  }

  deleteMessage(isDeletedOnlyForCreator: Boolean){
    this.roomService.deleteMessage(this.selectedMessage.id ?? -1, this.chatId, isDeletedOnlyForCreator).subscribe({
      next: _ => {if(isDeletedOnlyForCreator === true){this.getMessages(this.chatId);}},
      error: (err) => console.error(err)
    });
  }

  reply(isMessageReplyingOnlyForUser: Boolean){
    this.isMessageEditing = false;
    this.isMessageReplying = true;
    this.isMessageReplyingOnlyForUser = isMessageReplyingOnlyForUser;
  }

  edit(){
    this.isMessageReplying = false;
    this.isMessageEditing = true;
    this.text = this.selectedMessage.messageText;
  }

  setIsMessageEditingToFalse(){
    this.isMessageEditing = false;
  }

  setIsMessageReplyingToFalse(){
    this.isMessageReplying = false;
  }

  onContextMenu(event: any, message: Message, trigger: any) {
    this.selectedMessage = message; 
    event.preventDefault();
    this.trigger = trigger;
    this.openMenu = true;
  }

  logout(){
    this.authorizationService.logout();
  }

  public formatDate(message: Message){
    return message.activityDate;
  }
  
  get isMessageValid(): Boolean{
    if(this.text.length > 0)
    {
      return false
    }
    return true; 
  }

  get isAvailableNextPage(): Boolean{
    if(this.roomService.messageService.messages.length >= 20)
    {
      return true
    }
    return false; 
  }

  get isAvailablePreviousPage(): Boolean{
    if((this.page ?? 1) > 1)
    {
      return true
    }
    return false; 
  }
}