import { TestBed } from '@angular/core/testing';
import { SignalrService } from '../services/chat-signalr/chat-signalr-service';

describe('SignalrService', () => {
  let service: SignalrService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SignalrService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
