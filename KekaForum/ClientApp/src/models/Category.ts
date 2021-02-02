export class Category {

    id:number;
    name:string;
    description:string;
    weeklyTagCount:number;
    monthlyTagCount:number;
    totalQuestions:number;

    constructor(args:any){
        this.id = args.id;
        this.name = args.name;
        this.description = args.description;
        this.weeklyTagCount = args.weeklyTagCount;
        this.monthlyTagCount = args.monthlyTagCount;
        this.totalQuestions = args.totalQuestions;
    }
}
