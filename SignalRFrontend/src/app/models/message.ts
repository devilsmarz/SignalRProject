export class Message{
    id: number = 0;
    chatId: number = 0;
    userId: number = 0;
    messageText: string | null= '';
    activityDate: Date = new Date();
}