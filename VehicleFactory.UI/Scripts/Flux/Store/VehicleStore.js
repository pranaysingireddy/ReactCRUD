import AppDispatcher from '../Dispatcher';
import EventEmitter from 'events';
import { AppActionConstants } from '../Actions/AppActionConstants';

class VehicleStore extends EventEmitter {
    constructor() {
        super();
        this.vehicleGrid = {
            data: []
        };/*
        Need to register all actions with the AppDispatcher
        */

        AppDispatcher.register(action => {
            switch (action.type) {
                /*
                Action responsible for the initial data fetch
                */
                case AppActionConstants.fetchVehicles:
                    this.vehicleGrid.data = action.value.data;
                    this.emit('vehiclesfetch');
                    break;
                case AppActionConstants.saveVehicleSuccess:
                    this.emit('vehicleSaved');
                    break;
                case AppActionConstants.updateVehicleSuccess:
                    this.emit('vehicleUpdated');
                    break;
                case AppActionConstants.deleteVehicleSuccess:
                    this.emit('vehicleDeleted');
                    break;
                default:
                    break;
            }
        });
    }

    /*
    Getter function to return the current state
    */

    getData = () => this.vehicleGrid.data;

}

export default new CampaignsStore();
