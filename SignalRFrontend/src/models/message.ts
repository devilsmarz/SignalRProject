export interface Message{
    id: number;
    chatId: number;
    userId: number;
    messageText: string | null;
    activityDate: Date | null;
}