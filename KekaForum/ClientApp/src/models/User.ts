export class User {

    id:string;
    firstName:string;
    lastName:string;
    profilePicUrl:string;
    email:string;
    designation:string;
    department:string;
    location:string;
    totalLikes:number;
    totalDislikes:number;
    questionsAsked:number;
    questionsAnswered:number;
    questionsSolved:number;
    
    constructor(args:any){
        this.id=args.id;
        this.firstName=args.firstName;
        this.lastName=args.lastName;
        this.profilePicUrl=args.profilePicUrl;
        this.email=args.email;
        this.designation=args.designation;
        this.department=args.department;
        this.location=args.location;
    }
}
