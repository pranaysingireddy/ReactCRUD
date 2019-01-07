import React from 'react';
import { render } from 'react-dom';
import { DataTable } from 'carbon-components-react';
import { ViewVehicles } from '../Views/ViewVehicles.jsx';


const App = () => (
    <div>
        <h1>React in ASP.NET MVC Helo World!</h1>
        <div>Hello React World</div>
        <ViewVehicles />
    </div>
);


render(<App />, document.getElementById('app'));