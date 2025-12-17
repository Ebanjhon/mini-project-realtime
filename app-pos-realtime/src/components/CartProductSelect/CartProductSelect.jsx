import React from 'react'
import {formatPrice} from '../../utils/index';
const CartProductSelect = ({ data, increaseQuantity, decreaseQuantity, removeProductById }) => {
    return (
        <div className="flex items-center gap-3">
            <img
                src={data.images.length > 0 ? data.images[0].imageUrl : ''}
                alt={data.name}
                className="w-16 h-16 rounded-md object-cover border"
            />

            <div className="flex-1">
                <p className="text-sm font-medium text-gray-800">
                    {data.name}
                </p>
                <p className="text-xs text-gray-500">
                    {formatPrice(data.price)}
                </p>

                <div className="flex items-center gap-2 mt-2">
                    <button
                        onClick={() => decreaseQuantity(data.id)}
                        className="w-7 h-7 border rounded-md text-sm hover:bg-gray-100">
                        -
                    </button>
                    <span className="w-6 text-center text-sm">
                        {data.quantity}
                    </span>
                    <button
                        onClick={() => increaseQuantity(data.id)}
                        className="w-7 h-7 border rounded-md text-sm hover:bg-gray-100">
                        +
                    </button>
                </div>
            </div>

            {/* Total */}
            <div className="text-right">
                <p className="text-sm font-semibold text-gray-800">
                    {formatPrice(data.price * data.quantity)}
                </p>
                <button
                    onClick={() => removeProductById(data.id)}
                    className="text-xs text-red-500 hover:underline mt-1">
                    Xóa
                </button>
            </div>
        </div>
    )
}

export default CartProductSelect