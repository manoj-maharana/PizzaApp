import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cart, Pizza } from 'src/app/helpers/models/pizza.model';



@Component({
  selector: 'app-cart-preview',
  templateUrl: './cart-preview.component.html',
  styleUrls: ['./cart-preview.component.scss']
})
export class CartPreviewComponent implements OnInit {
  public cart: Cart | null = null;
  public cartItems: Pizza[] = [];
  public subtotal: number | null = null;
  public isCartExpanded: boolean = false;

  constructor(
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.getState();
  }

  getState() {
    this.subtotal = 10;
  }

  toggleCart() {
    this.isCartExpanded = !this.isCartExpanded;
  }
  
  expandCart() {
    this.isCartExpanded = true;
  }

  collapseCart() {
    this.isCartExpanded = false;
  }

  checkout() {
    this.router.navigateByUrl('/checkout');
  }
}
