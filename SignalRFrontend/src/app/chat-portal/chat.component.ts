import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Message } from 'src/models/message';
import { RoomService } from 'src/services/room-service/room-service';
import { MessageService } from 'src/services/message-service/message-service';
import { Chat } from 'src/models/chat';


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  title = 'chat-ui';
  text: string = "";
  message: Message = new Message();

  constructor(public roomService: RoomService) {
  }

  ngOnInit(): void {
    this.roomService.connect();
  }

  sendMessage(): void {
    //Need to be removed
    this.message.messageText = this.text;
    this.message.userId = Number.parseInt(localStorage.getItem("userId") ?? "-1");
    //

    this.roomService.sendMessage(this.message).subscribe({
      next: _ => {this.text = ''; this.message = new Message();},
      error: (err) => console.error(err)
    });
  }

  joinRoom(chat: Chat){
    this.roomService.joinRoom(chat);
    this.roomService.getMessages(chat.id ?? -1);
  }
  
  public get isMessageValid(): Boolean{
    if(this.text.length > 0)
    {
      return false
    }
    return true; 

  }
}