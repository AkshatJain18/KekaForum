import { Time } from "@angular/common";

export class Answer {
    
    id:number;
    questionId:number;
    dateCreated:Date;
    userFirstName:string;
    userLastName:string;
    answer:string;
    likesCount:number;
    dislikesCount:number;

    constructor(args:any){
        this.id = args.id;
        this.questionId = args.questionId;
        this.dateCreated = args.dateCreated;
        this.userFirstName = args.userFirstName;
        this.userLastName = args.userLastName;
        this.answer = args.answer;
        this.likesCount = args.likesCount;
        this.dislikesCount = args.dislikesCount;
    }
}
