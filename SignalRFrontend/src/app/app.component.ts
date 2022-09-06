import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { SignalrService } from '../shared/chat-signalr/chat-signalr-service';
import { Message } from './models/message';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'chat-ui';
  text = new FormControl('', [Validators.required]);

  constructor(public signalRService: SignalrService, public http: HttpClient) {
  }

  ngOnInit(): void {
    this.signalRService.connect();
  }

  sendMessage(): void {
    this.http.delete("chat/5").subscribe();
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