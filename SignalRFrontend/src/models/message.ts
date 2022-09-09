import { Chat } from "./chat";
import { User } from "./user";

export class Message{
    id: number | null = null;
    chatId: number = 1;
    userId: number = 1;
    receiverId: number | null = null;
    userName: string | null = "";
    messageText: string  = "";
    isDeletedForMe: boolean = false;
    activityDate: Date | null = null;
    user: User | null= null;
    receiver: User | null= null;
    chat: Chat | null= null;
}