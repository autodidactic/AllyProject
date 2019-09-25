import { Component, OnInit } from '@angular/core';


import { AuctionItems } from '../Models/AuctionItems';

import ApiService from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './HTML/app.component.html',
  styleUrls: ['./HTML/app.component.scss']
})
export class AppComponent implements OnInit  {
  auctions: Array<AuctionItems>;

  constructor(private apiService: ApiService) {
  }

  ngOnInit() {
    this.apiService.getAll().subscribe(data => {
      this.auctions = data;
    });
  }

    this.apiService
    .CreateAuction(AuctionItems)
        .subscribe(auction => this.auctions.push(auction
        ));

}
