import { TestBed } from '@angular/core/testing';

import { ProdkucService } from './prodkuc.service';

describe('ProdkucService', () => {
  let service: ProdkucService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProdkucService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
