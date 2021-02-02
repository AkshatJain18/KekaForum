export class Question {

    id:number;
    title:string;
    description:string;
    dateCreated:string;
    userFirstName:string;
    userLastName:string;
    userProfilePicUrl:string;
    upvotesCount:number;
    viewsCount:number;
    answersCount:number;
    isResolved:boolean;

    constructor(args:any){
        this.id = args.id;
        this.title = args.title;
        this.description = args.description;
        this.userFirstName = args.userFirstName;
        this.userLastName = args.userLastName;
        this.upvotesCount = args.upvotesCount;
        this.answersCount = args.answersCount;
        this.isResolved = args.isResolved;
    }
}
