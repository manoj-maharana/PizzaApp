import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartSelectorComponent } from './cart-selector.component';

describe('CartSelectorComponent', () => {
  let component: CartSelectorComponent;
  let fixture: ComponentFixture<CartSelectorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CartSelectorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CartSelectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
