import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Message } from 'src/models/message';
import { Chat } from 'src/models/chat';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  apiUrl: string = "Chat";
  chats: Chat[] = [];

  constructor(private http: HttpClient) {}
  
  public getChats(){
    this.http.get<Chat[]>(`${this.apiUrl}/GetAllChats/${localStorage.getItem("userId")}`)
        .subscribe(chats => this.chats = chats);
  }
}