import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { SignalrService } from '../shared/chat-signalr/chat-signalr-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'chat-ui';
  text = new FormControl('', [Validators.required]);

  constructor(public signalRService: SignalrService) {
  }

  ngOnInit(): void {
    this.signalRService.connect();
  }

  sendMessage(): void {
    let message: Message = new Message();
    message.chatId = 1;
    message.userId = 1;
    message.messageText = this.text.value;

    this.signalRService.sendMessageToHub(message).subscribe({
      next: _ => this.text.setValue(''),
      error: (err) => console.error(err)
    });
  }
  
}
class Message{
    id: number = 0;
    chatId: number = 0;
    userId: number = 0;
    messageText: string | null= '';
    activityDate: Date = new Date();
}