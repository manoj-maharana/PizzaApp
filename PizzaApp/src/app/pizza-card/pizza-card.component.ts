import { Component, Input, OnInit } from '@angular/core';
import {  Pizza } from 'src/app/helpers/models/pizza.model';
import {  ICurrency } from 'src/app/helpers/models/currency.model';
import {  Currency } from 'src/app/helpers/enums/currency.enums';
import { PizzaService } from '../services/pizza.services';

@Component({
  selector: 'app-pizza-card',
  templateUrl: './pizza-card.component.html',
  styleUrls: ['./pizza-card.component.scss']
})
export class PizzaCardComponent implements OnInit {
  @Input('pizza-data') pizza: any | null = null;

  public currency: ICurrency = {
    inr: Currency.india,
    usd: Currency.usa,
  }

 constructor(private pizzaStore: PizzaService) { }

  ngOnInit(): void {
    this.getCartItemState();
  }

  getCartItemState() {
    // this.store.select(fromReduders.selectCartPizza(this.pizza))
    //   .subscribe({
    //     next: (res) => {
    //       if (res && Object.keys(res).length) {
    //         this.pizza = res;
    //       }
    //     }
    //   });

    this.pizzaStore.getallpizza().subscribe({
          next: (res) => {
            if (res && Object.keys(res).length) {
              this.pizza = res;
            }
          }
        });
  }
}
