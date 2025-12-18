import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import * as signalR from '@microsoft/signalr';
import connection, { API_HOST } from '../../configs';
import ItemOrder from './ItemOrder/ItemOrder';
import axios from 'axios';

const Order = () => {
    const [status, setStatus] = useState(false);
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        connection.start()
            .then(() => { setStatus(true) })
            .catch(err => console.log(err));

        connection.on("ReceiveMessage", (message) => {
            getOrderById(message.orderId)
        });

        return () => {
            connection.off("ReceiveMessage");
            setStatus(false)
        }
    }, []);

    const getOrderById = async (orderId) => {
        try {
            const res = await axios.get(`${API_HOST}/Order/GetOrderById`, {
                params: { Id: orderId }
            });
            if (res.data.success && res.data !== null) {
                setOrders(prev => [res.data.data, ...prev]);
            }
        } catch (error) {
            console.log("thất bại")
        }
    }

    return (
        <div className="flex flex-col h-screen bg-slate-100">
            <div className='w-full pb-2 flex justify-center items-center gap-2'>
                <h2 className='text-2xl font-bold'>Lịch sử đơn hàng</h2>
                <div className={`w-3 h-3 rounded-full ${status ? 'bg-green-500 animate-pulse' : 'bg-red-500'}`} />
            </div>

            {/* list item */}
            <div className="px-2 h-full overflow-y-auto">
                <div className="grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 gap-6">
                    {orders.map(item => (
                        <ItemOrder data={item} key={item.id} />
                    ))}
                </div>
            </div>
        </div>
    )
}

export default Order