import React, { useState } from 'react'
import { formatDateTime } from '../../../utils';

const ItemOrder = ({data}) => {
    console.log("ItemOrder render:", data);
    if (!data) return null;
    const total = data.orderProducts.reduce((sum, i) => sum + i.quantity * i.product.price, 0);
    return (
        <div className="max-w-xl bg-white rounded-2xl shadow-lg hover:shadow-2xl transition-all duration-300 p-6 space-y-4 hover:-translate-y-1" style={{height:"500px"}}>
            <div className="flex justify-between items-start">
                <div>
                    <h3 className="text-lg font-semibold text-gray-800">
                        Nhân viên: <span className="font-bold">Y Jhon Êban</span>
                    </h3>
                    <p className="text-sm text-gray-500">
                        Mã đơn hàng: <span className="font-medium">{data.id}</span>
                    </p>
                </div>

                <div className="text-right">
                    <span className="inline-block px-3 py-1 mt-1 rounded-full text-sm font-semibold bg-green-100 text-green-700">
                        Đã thanh toán
                    </span>
                </div>
            </div>

            <p className="text-sm text-gray-500">
                Ngày thanh toán: <span className="font-medium">{formatDateTime(data.createdAt)}</span>
            </p>

            <hr className="border-dashed" />

            <div className="relative rounded-xl border border-gray-100 overflow-hidden" style={{ height: "210px" }}>
  
  {/* Table */}
  <table className="w-full text-sm">
    <thead className="bg-gray-50 text-gray-600">
      <tr>
        <th className="px-4 py-2 text-left">Mã</th>
        <th className="px-4 py-2 text-left">Sản phẩm</th>
        <th className="px-4 py-2 text-center">SL</th>
        <th className="px-4 py-2 text-right">Thành tiền</th>
      </tr>
    </thead>

    <tbody className="bg-white/70 backdrop-blur">
      {data?.orderProducts?.map((item, idx) => (
        <tr key={idx} className="hover:bg-gray-50 transition">
          <td className="px-4 py-2 font-medium">{item.product.id}</td>
          <td className="px-4 py-2">{item.product.productName}</td>
          <td className="px-4 py-2 text-center">{item.quantity}</td>
          <td className="px-4 py-2 text-right font-semibold">
            {(item.quantity * item.product.price).toLocaleString()} VND
          </td>
        </tr>
      ))}
    </tbody>
  </table>

  {/* Fade bottom */}
  <div className="pointer-events-none absolute bottom-0 left-0 w-full h-12 
                  bg-gradient-to-t from-white to-transparent" />
</div>


            <hr className="border-dashed" />

            <div className="flex justify-between items-center">
                <p className="text-base font-semibold text-gray-700">Tổng đơn giá</p>
                <span className="text-xl font-bold text-blue-600">
                    {total.toLocaleString()} VND
                </span>
            </div>

            <button className="w-full mt-2 py-3 rounded-xl text-white font-semibold bg-gradient-to-r from-blue-500 to-indigo-500
                   hover:from-indigo-500 hover:to-blue-500 transition-all duration-300 shadow-md hover:shadow-lg">
                Xem chi tiết đơn hàng
            </button>
        </div>
    )
}

export default ItemOrder