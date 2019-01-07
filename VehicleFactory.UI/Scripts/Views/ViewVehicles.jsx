import React, { Component } from 'react';
import 'react-table/react-table.css';
import { vehicleData } from '../../Flux/Actions/VehicleActions';



const defaultColumns = [
    {
        Header: "Manufacturer",
        accessor: "Manufacturer"
    },
    {
        Header: "Make",
        accessor: "Make"
    },
    {
        Header: "Model",
        accessor: "Model"
    },
    {
        Header: "Year",
        accessor: "Year"
    }
];



class ViewVehicles extends Component {
    constructor() {
        super();
        this.state = {
            isHidden: false,
            columns: defaultColumns,
        };

    }

    componentWillMount = () => {

        const configReq = vehicleData();
        configReq.then(() => {
            this.setState(
                { vehiclessData: VehicleStore.getData(), columns= defaultColumns }
            );
        });
    };

    render() {
        const { vehiclessData, columns } = this.state;
        return (
            <section>
                <div>
                    <Grid columns={columns} data={vehiclessData} loading={false} pageSize={15} />
                </div>

            </section>
        );
    }
}

export default ViewVehicles;
