import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({providedIn:'root'})
export class PizzaService {
    public baseUrl = "https://localhost:7160/v1/pizza";
    constructor(private http: HttpClient) { }   


    getallpizza(){
        let url = this.baseUrl + '/getallpizza' ;
        return this.http.get(url);
    }

    getpizzadetails(id:any){
        let url = this.baseUrl + '/getallpizza' + id ;
        return this.http.get(url);
    }

    addnewpizza(val:any){
        let url = this.baseUrl + '/getallpizza' ;
        return this.http.post(url,val);
    }

}