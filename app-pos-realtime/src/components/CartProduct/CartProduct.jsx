import React from 'react'
import { formatPrice } from '../../utils';

const CartProduct = ({ product, onAddToCart }) => {
    return (
        <div className="border rounded-lg shadow hover:shadow-lg transition p-3 flex flex-col bg-white" style={{ height: "406px" }}>
            <img
                src={product.imageObjs.length > 0
                    ? product.imageObjs[0].imageUrl
                    : "https://via.placeholder.com/150"}
                alt={product.productName}
                className="w-full h-48 flex-shrink-0 object-cover rounded-md mb-2 bg-gray-300 transform transition duration-300 ease-in-out hover:scale-105"
            />

            <div className="flex-1 flex flex-col justify-start">
                <h3 className="text-lg font-semibold text-left line-clamp-2">
                    {product.productName}
                </h3>

                <p className="text-gray-500 text-sm text-left line-clamp-2">
                    {product.description || " "}
                </p>
            </div>

            <div className="mt-2">
                <p className="text-blue-600 font-bold text-lg mb-2 text-left">{formatPrice(product.price.toLocaleString())}</p>

                <button
                    onClick={() => onAddToCart(product)}
                    className="bg-blue-600 hover:bg-blue-700 text-white font-medium rounded-md px-4 py-2 w-full transition">
                    Thêm vào giỏ
                </button>
            </div>
        </div>
    );
};


export default CartProduct