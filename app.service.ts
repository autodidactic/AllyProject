import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { AuctionItems } from '../Models/AuctionItems';

@Injectable
public default class ApiService {
    public API = https://localhost:5001/api/values;

    public postUrl = 'https://localhost:5001/api/bids';
 
  public AUCTION_ITEM_ENDPT = `${this.API}/auctionItems`;

    const httpOptions = {
        headers: new HttpHeaders({
        'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'

        })
    };

 constructor(private http: HttpClient) { }

  getAll(): Observable<Array<AuctionItems>> {
    return this.http.get<Array<AuctionItems>>(this.AUCTION_ITEM_ENDPT);
  }

    CreateAuction(items: AuctionItems) Observable<AuctionItems>
    {
        return this.http.post<AuctionItems>(this.postUrl, this.items.auctionitemId, this.httpOptions)
            .pipe(
                catchError(this.errorHandler()
                );
    }

 

}