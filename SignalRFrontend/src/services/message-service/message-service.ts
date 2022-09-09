import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr'
import { from, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { MessagePackHubProtocol } from '@microsoft/signalr-protocol-msgpack'
import { Message } from 'src/models/message';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  apiUrl: string = "Message";
  messages: Message[] = [];

  constructor(private http: HttpClient) { }

  public sendMessage(message: Message) {
    return this.http.post(this.apiUrl, message);
  }

  public updateMessage(message: Message) {
    return this.http.put(this.apiUrl, message);
  }

  public getMessages(chatId: number){
    this.http.get<Message[]>(`${this.apiUrl}/${chatId}/${localStorage.getItem("userId")}`)
        .subscribe(messages => this.messages = messages);
  }

  public deleteMessage(messageId: number){
    return this.http.get<Message[]>(this.apiUrl);
  }
}