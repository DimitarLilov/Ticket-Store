import { Component, OnInit } from '@angular/core';
import { Ad } from '../../../domain/index';
import { AdService } from '../../../services';

@Component({
    selector: 'app-ad-list',
    templateUrl: './admin-ad.component.html',
    styleUrls: ['./admin-ad.component.css']
})

export class AdminAllAdsComponent implements OnInit{
    ads : Ad[];

    constructor(private AdService : AdService) {}

    ngOnInit(): void {
        this.AdService.getAll().subscribe((data) => {
            this.ads = data;
        });
    }
}
