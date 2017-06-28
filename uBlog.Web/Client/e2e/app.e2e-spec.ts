import { UblogPage } from './app.po';

describe('ublog App', () => {
  let page: UblogPage;

  beforeEach(() => {
    page = new UblogPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
