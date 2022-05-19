import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { TablicaDataSource, TablicaItem } from './tablica-datasource';

@Component({
  selector: 'app-tablica',
  templateUrl: './tablica.component.html',
  styleUrls: ['./tablica.component.css']
})
export class TablicaComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<TablicaItem>;
  dataSource: TablicaDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name','godinaProdukcije', 'zarada','actions'];

  constructor() {
    this.dataSource = new TablicaDataSource();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }
}
