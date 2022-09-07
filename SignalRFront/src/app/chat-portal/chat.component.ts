import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Message } from 'src/models/message';
import { SignalrService } from 'src/shared/chat-signalr/chat-signalr-service';


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  title = 'chat-ui';
  text = new FormControl('', [Validators.required]);
  message: Message | undefined;

  constructor(public signalRService: SignalrService) {
  }

  ngOnInit(): void {
    this.signalRService.connect();
  }

  sendMessage(): void {
    this.message = {
      id: 1,
      chatId: 1,
      userId: 1,
      messageText: this.text.value,
      activityDate: null,
  };

    this.signalRService.sendMessageToApi(this.message).subscribe({
      next: _ => this.text.setValue(''),
      error: (err) => console.error(err)
    });
  }
  
}