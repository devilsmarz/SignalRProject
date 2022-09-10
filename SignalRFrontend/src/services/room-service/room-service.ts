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
        this.chatService.getChats();
      })
      )
      .catch((err) => {console.log('error while establishing signalr connection: ' + err); this.isConnected = false;})
  }

  private addListeners() {
    this.hubConnection.on("ReceiveNewMessage", (data: string) => {
      let newMessage: Message = JSON.parse(data); 
      if(this.messageService.messages.length < 20)
      {
        this.messageService.messages.push(newMessage);
      }
    });

    this.hubConnection.on("ReceiveUpdatedMessage", (data: string) => {
      let updatedMessage: Message = JSON.parse(data); 
      for(let message of this.messageService.messages)
      {
        if(message.id === updatedMessage.id)
        {
          message = updatedMessage;
        }
      }
    });

    this.hubConnection.on("DeleteMessage", (data: string) => {
      let updatedMessage: Message = JSON.parse(data); 
      for(let message of this.messageService.messages)
      {
        //this.messageService.getMessages
      }
    });
  }
  public leaveRoom(chatId: number){
    var promise = this.hubConnection.invoke("leaveRoom", chatId?.toString())
    .then(() => { console.log('Join group sent successfully to hub'); this.isConnected = false;})
    .catch((err) => console.log('error while sending a join to group in hub: ' + err));

  return from(promise);
  }

  public joinRoom(chatId: number) {
    var promise = this.hubConnection.invoke("joinRoom", chatId.toString())
      .then(() => { console.log('Join group sent successfully to hub'); this.isConnected = true;})
      .catch((err) => console.log('error while sending a join to group in hub: ' + err));

    return from(promise);
  }

  public sendMessage(message: Message){
    return this.messageService.sendMessage(message);
  }
  
  public getMessages(chatId: number, page: number | null){
    return this.messageService.getMessages(chatId, page);
  }
}