import * as signalR from '@microsoft/signalr';

export const API_HOST = process.env.REACT_APP_API_HOST;

const connection = new signalR.HubConnectionBuilder()
    .withUrl(`http://localhost:8080/orderhub`)
    .withAutomaticReconnect()
    .build();

export default connection;