import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Message } from 'src/models/message';
import { SignalrService } from 'src/services/chat-signalr/chat-signalr-service';


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  title = 'chat-ui';
  text: string = "";
  message: Message = new Message();
  @ViewChild('message') inputMessage: { nativeElement: { value: string; }; } | undefined; 

  constructor(public signalRService: SignalrService) {
  }

  ngOnInit(): void {
    this.signalRService.connect();
  }

  sendMessage(): void {
    //Need to be removed
    this.message.messageText = this.text;
    //

    this.signalRService.sendMessageToApi(this.message).subscribe({
      next: _ => {this.text = ''; this.message = new Message();},
      error: (err) => console.error(err)
    });
  }
  
  public get isMessageValid(): Boolean{
    if(this.text.length > 0)
    {
      return false
    }
    return true; 

  }
}