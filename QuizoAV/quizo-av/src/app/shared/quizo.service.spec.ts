import { TestBed } from '@angular/core/testing';

import { QuizoService } from './quizo.service';

describe('QuizoService', () => {
  let service: QuizoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QuizoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
