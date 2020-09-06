import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { AccountService } from 'src/app/account/account.service';
import { OrdersService } from './orders/orders.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {

  title = 'Skinet';

  constructor(private basketService: BasketService, private accountService: AccountService, private ordersService: OrdersService) {}

  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
   }

   // tslint:disable-next-line: typedef
   loadCurrentUser() {
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe(() => {
      console.log('loaded user');
    }, error => {
         console.log(error);
    });
  }


   // tslint:disable-next-line: typedef
   loadBasket() {
    const basketId = localStorage.getItem('basket_id');
    if ( basketId ) {
      this.basketService.getBasket(basketId).subscribe(() => {
        console.log('initialized basket');
      }, error => {
        console.log(error);
      });
    }
   }


}
