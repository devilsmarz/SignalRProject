import { Chat } from "./chat";
import { Message } from "./message";

export class User{
    id: number | null = null;
    userName: string = "";
    chats: Chat[]  = [];
    messages: Message[]  = [];
}
