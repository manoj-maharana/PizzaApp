import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { Pizza } from 'src/app/helpers/models/pizza.model';

import { PizzaService } from '../../services/pizza.services';
@Component({
  selector: 'app-pizzas',
  templateUrl: './pizzas.component.html',
  styleUrls: ['./pizzas.component.scss']
})
export class PizzasComponent implements OnInit {

    pizzas:any=[];
  constructor(private pizzaStore: PizzaService) { }

  ngOnInit(): void {
   this.loadPizzas();
  }

  loadPizzas() {
    this.pizzaStore.getallpizza().subscribe(x=>{
        this.pizzas = x;
      });
  }




}
