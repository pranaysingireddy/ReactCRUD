import axios from 'axios';
import path from 'path';

class AppConfig {
    constructor() {

      this.apiPath = {
            ApiBasePath: document.querySelector('#apiUrl').value,
            // ApiKey: 'Yqh+okY7x0q57FA0WsDVCA==',
        };

    }

    getApiBasePath = () => this.book;
}

export default new AppConfig();
