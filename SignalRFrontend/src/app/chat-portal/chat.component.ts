import { Component, OnInit, ViewChild } from '@angular/core';
import { Message } from 'src/models/message';
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

  constructor(public roomService: RoomService) {
  }

  ngOnInit(): void {
    this.roomService.connect();
  }

  sendMessage(): void {
    //Need to be removed
    this.message.messageText = this.text;
    this.message.userId = Number.parseInt(localStorage.getItem("userId") ?? "-1");
    this.message.userName = localStorage.getItem("userName");
    //

    this.roomService.sendMessage(this.message).subscribe({
      next: _ => {this.text = ''; this.message = new Message();},
      error: (err) => console.error(err)
    });
  }

  joinRoom(newChatId: number){
    if(this.chatId != -1){this.roomService.leaveRoom(this.chatId); this.roomService.messageService.messages = []}
    this.roomService.joinRoom(newChatId);
    this.roomService.getMessages(newChatId, this.page).subscribe(pageInfo => 
      {
        this.roomService.messageService.messages = pageInfo.messages;
        this.page = pageInfo.currentPageNumber;
      });
    this.chatId = newChatId;
  }
  
  public get isMessageValid(): Boolean{
    if(this.text.length > 0)
    {
      return false
    }
    return true; 
  }

  public get isAvailableNextPage(): Boolean{
    if(this.roomService.messageService.messages.length < 20)
    {
      return false
    }
    return false; 
  }

  public get isAvailablePreviousPage(): Boolean{
    if(this.page ?? 0 > 0)
    {
      return true
    }
    return false; 
  }
}