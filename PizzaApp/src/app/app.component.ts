import { Component } from '@angular/core';
import { PizzaService } from './services/pizza.services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'PizzaApp';
  pizzas:any=[];
  constructor(private pizzaStore: PizzaService) { }

  ngOnInit(): void {
    this.getCartItemState();
  }

  getCartItemState() {
    
    this.pizzaStore.getallpizza().subscribe({
          next: (res) => {
            if (res && Object.keys(res).length) {
              this.pizzas = res;
            }
          }
        });
}
}
