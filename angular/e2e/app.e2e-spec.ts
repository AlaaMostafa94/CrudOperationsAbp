import { CrudOperationsTemplatePage } from './app.po';

describe('CrudOperations App', function() {
  let page: CrudOperationsTemplatePage;

  beforeEach(() => {
    page = new CrudOperationsTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
