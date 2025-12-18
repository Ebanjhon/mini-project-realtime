import React, { useState, forwardRef, useImperativeHandle } from 'react'
import CartProductSelect from '../../../components/CartProductSelect/CartProductSelect';
import { formatPrice } from '../../../utils';
import { API_HOST } from '../../../configs';
import axios from 'axios';
import { toast } from "react-toastify";

const OrderDetail = forwardRef((props, ref) => {
    const [products, setProducts] = useState([]);

    useImperativeHandle(ref, () => ({
        setOrderFromParent: (value) => {
            if (products.some(item => item.id === value.id)) {
                return;
            }

            const formatted = {
                id: value.id,
                name: value.productName,
                price: value.price,
                images: value.imageObjs || [],
                quantity: 1
            };

            setProducts(prev => [...prev, formatted]);
        }
    }));

    const increaseQuantity = (id) => {
        setProducts(prev =>
            prev.map(item =>
                item.id === id ? { ...item, quantity: item.quantity + 1 } : item
            )
        );
    }

    const decreaseQuantity = (id) => {
        setProducts(prev =>
            prev.map(item =>
                item.id === id
                    ? { ...item, quantity: Math.max(1, item.quantity - 1) }
                    : item
            )
        );
    }

    const removeProductById = (id) => {
        setProducts(prev => prev.filter(item => item.id !== id));
    }

    const handleOrder = async () => {
        const apiData = {
            status: 1,
            ProductObjs: products.map(p => ({
                productID: p.id,
                quantity: p.quantity
            }))
        };

        try {
            const res = await axios.post(`${API_HOST}/Order/CreateOrder`, apiData);
            if (res.data.success) {
                toast.success("Thanh toán thành công!");
                setProducts([]);
            }else{
                toast.warning("Có lỗi xảy ra, vui lòng thử lại!");
            }
        } catch (error) {
                toast.error("Có lỗi xảy ra!");
        }
    };

    return (
        <div className='rounded-lg shadow-sm border flex flex-col h-full'>
            <h2 className="text-xl font-bold w-full ml-2 mt-2">Chi tiết giỏ hàng</h2>
            <div className="flex items-center justify-between border-b mx-2 pb-2 px-2" style={{ margin: "0px" }}>
                <p className="text-sm text-gray-700">
                    Đã chọn {products.length} sản phẩm
                </p>
                <button type='button' onClick={() => setProducts([])} className="text-sm text-red-600 hover:underline">
                    Xóa tất cả
                </button>
            </div>

            {/* Product list */}
            <div className="flex flex-col flex-1 overflow-y-auto px-2 mb-1" style={{ marginTop: "0px" }}>
                {products.map(((item, index) => (
                    <>
                        <CartProductSelect data={item} key={item.id} increaseQuantity={increaseQuantity} decreaseQuantity={decreaseQuantity} removeProductById={removeProductById} />
                        {index !== products.length - 1 && (
                            <hr className='border-t-2 border-dashed border-gray-400 my-1' />
                        )}
                    </>
                )))}

                {products.length === 0 && (
                    <p className="text-center text-gray-500 mt-8">
                        Chưa thêm sản phẩm nào.
                    </p>
                )}
            </div>

            <button
                type="button"
                onClick={handleOrder}
                disabled={products.length === 0}
                className={`m-2 relative group px-4 py-4 text-white font-semibold text-lg rounded-xl overflow-hidden transition-all duration-500 flex justify-between items-center 
                    ${products.length === 0 ? "bg-gray-400 cursor-not-allowed" : "bg-gradient-to-r from-blue-500 to-pink-300 hover:bg-gradient-to-l hover:from-pink-300 hover:to-blue-500 hover:shadow-2xl hover:scale-105"}`}>
                <span className="relative z-10 uppercase">
                    {formatPrice(products.reduce((acc, item) => acc + item.price * item.quantity, 0))}
                </span>
                <span className="relative z-10 uppercase">Thanh toán</span>
                {products.length > 0 && (
                    <>
                        <div className="absolute inset-0 -translate-x-full skew-x-12 bg-gradient-to-r from-transparent via-white to-transparent opacity-50 group-hover:translate-x-full group-hover:duration-1000 transition-transform duration-1000"></div>
                        <div className="absolute -inset-1 bg-gradient-to-r from-blue-500 to-pink-300 rounded-xl blur-lg opacity-40 group-hover:opacity-80 transition-opacity duration-1000"></div>
                    </>
                )}
            </button>

        </div >
    )
});

export default OrderDetail