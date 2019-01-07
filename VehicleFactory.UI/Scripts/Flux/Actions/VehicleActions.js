import axios from 'axios';
import AppDispatcher from '../Dispatcher';
import { AppActionConstants } from './AppActionConstants';
import AppConfig from '../../AppConfig';

const basePath = AppConfig.ApiBasePath();

export const vehicleData = () => {
    return axios
        .get(
        `${basePath.ApiBasePath}/api/vehicles`,
            {
                responseType: 'json',
            }
        )
        .then(response => {
            console.log('axios call made');
            AppDispatcher.dispatch({
                type: AppActionConstants.fetchVehicles, // "FETCHVEHICLES"
                value: response.data,
            });
        });
};


export const saveVehicle = (vehicle) => {
    const postData = JSON.stringify(vehicle);
    return axios
        .post(`${basePath.ApiBasePath}/api/vehicles`, postData, {
            headers: {
                'Content-Type': 'application/json',
            },
        })
        .then(resp => {
            AppDispatcher.dispatch({
                type: AppActionConstants.saveVehicleSuccess, // "SAVEVEHICLESUCCESS"
                value: resp.data,
            });
        });
      
};

export const updateVehicle = (vehicle) => {
    const postData = JSON.stringify(vehicle);
    return axios
        .put(`${basePath.ApiBasePath}/api/vehicles`, postData, {
            headers: {
                'Content-Type': 'application/json',
            },
        })
        .then(resp => {
            AppDispatcher.dispatch({
                type: AppActionConstants.updateVehicleSuccess, // "UPDATEVEHICLESUCCESS"
                value: resp.data,
            });
        });

};


export const updateVehicle = (vehicleId) => {
    
    return axios
        .delete(`${basePath.ApiBasePath}/api/vehicles/vehicleId`, {
            headers: {
                'Content-Type': 'application/json',
            },
        })
        .then(resp => {
            AppDispatcher.dispatch({
                type: AppActionConstants.deleteVehicleSuccess, // "DELETEVEHICLESUCCESS"
                value: resp.data,
            });
        });

};


