/// <reference path="../../../node_modules/@types/jasmine/index.d.ts" />
import {
  TestBed,
  async,
  ComponentFixture,
  ComponentFixtureAutoDetect
} from '@angular/core/testing';
import {BrowserModule, By} from '@angular/platform-browser';
import {ClientComponent} from './client.component';

let component: ClientComponent;
let fixture: ComponentFixture<ClientComponent>;

describe('Client component', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ClientComponent],
      imports: [BrowserModule],
      providers: [{provide: ComponentFixtureAutoDetect, useValue: true}]
    });
    fixture = TestBed.createComponent(ClientComponent);
    component = fixture.componentInstance;
  }));

  it('should do something', async(() => {
    expect(true).toEqual(true);
  }));
});
