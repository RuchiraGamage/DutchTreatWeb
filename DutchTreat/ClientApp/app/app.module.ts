import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'

//import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductList } from './shop/productList.component'
import { DataService } from './shared/dataService';
import { Cart } from './shop/cart.component';
import { RouterModule } from '@angular/router'
import { Shop } from './shop/shop.component';
import { Checkout } from './checkout/checkout.component';
import { Login } from './login/login.component';

let routes = [
    {path:"",component:Shop},
    { path: "checkout", component: Checkout },
    { path: "login", component: Login }
];

@NgModule({
  declarations: [
      AppComponent,
      ProductList,
      Cart,
      Shop,
      Checkout,
      Login
  ],
  imports: [    
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(routes, {
          useHash: true,
          enableTracing: false//for debuging of the routes
      })
  //  AppRoutingModule
  ],
    providers: [
        DataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
