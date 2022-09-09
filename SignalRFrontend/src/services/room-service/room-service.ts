import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr'
import { from } from 'rxjs';
import { Chat } from 'src/models/chat';
import { Message } from 'src/models/message';
import { ChatService } from '../chat-service/chat-service';
import { MessageService } from '../message-service/message-service';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  private hubConnection: HubConnection;
  public chats: Chat[] = [];
  private connectionUrl = 'https://localhost:5001/signalr';
  private connectionId = "";
  public isConnected = false;

  constructor(private http: HttpClient, public chatService: ChatService, public messageService: MessageService) { this.hubConnection = this.getConnection();}

  public connect = () => {
    this.startConnection();
    this.addListeners();
  }

  private getConnection(): HubConnection {
    return new HubConnectionBuilder()
      .withUrl(this.connectionUrl)
      .build();
  }

  private startConnection() {

    
    this.hubConnection.start()
      .then(() => this.hubConnection.invoke("getConnectionId")
      .then((connectionId) => {this.connectionId = connectionId; 
        this.isConnected = true; 
        this.chatService.getChats();
      })
      )
      .catch((err) => {console.log('error while establishing signalr connection: ' + err); this.isConnected = false;})
  }

  private addListeners() {
    this.hubConnection.on("ReceiveMessage", (data: string) => {
      let message: Message = JSON.parse(data); 
      this.messageService.messages.push(message);
    })
  }
  // public joinRoom(chat: Chat){
  //   this.http.post(`Room/JoinRoom/${this.connectionId}/${chat.name}`,{});
  //   this.messageService.getMessages(chat.id ?? -1);
  // }

  public joinRoom(chat: Chat) {
    var promise = this.hubConnection.invoke("joinRoom", chat.id?.toString())
      .then(() => { console.log('Join group sent successfully to hub'); })
      .catch((err) => console.log('error while sending a join to group in hub: ' + err));

    return from(promise);
  }

  public sendMessage(message: Message){
    return this.messageService.sendMessage(message);
  }
  
  public getMessages(chatId: number){
    return this.messageService.getMessages(chatId);
  }
}