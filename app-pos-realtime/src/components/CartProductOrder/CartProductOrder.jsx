import React, { useState } from "react";

const sampleData = [
    {
        id: 1,
        name: "Cà phê sữa đá",
        price: 25000,
        quantity: 2,
        image:
            "https://images.unsplash.com/photo-1509042239860-f550ce710b93?w=300",
    },
    {
        id: 2,
        name: "Trà đào cam sả",
        price: 30000,
        quantity: 1,
        image:
            "https://images.unsplash.com/photo-1510627498534-cf7e9002facc?w=300",
    },
];

const formatPrice = (value) =>
    value.toLocaleString("vi-VN") + " ₫";

const CartProductOrder = () => {
    const [items, setItems] = useState(sampleData);

    const updateQty = (id, type) => {
        setItems((prev) =>
            prev.map((item) =>
                item.id === id
                    ? {
                        ...item,
                        quantity:
                            type === "inc"
                                ? item.quantity + 1
                                : Math.max(1, item.quantity - 1),
                    }
                    : item
            )
        );
    };

    const removeItem = (id) => {
        setItems((prev) => prev.filter((i) => i.id !== id));
    };

    const totalPrice = items.reduce(
        (sum, i) => sum + i.price * i.quantity,
        0
    );

    return (
        <div className="rounded-lg shadow-sm border p-4 space-y-4 flex-1 overflow-y-auto">
            {/* Header */}
            <div className="flex items-center justify-between border-b pb-2">
                <p className="text-sm text-gray-700">
                    Đã chọn {items.length} sản phẩm
                </p>
                <button className="text-sm text-red-600 hover:underline">
                    Xóa tất cả
                </button>
            </div>

            {/* Product list */}
            <div className="space-y-4">
                {items.map((item) => (
                    <div
                        key={item.id}
                        className="flex items-center gap-3"
                    >
                        {/* Image */}
                        <img
                            src={item.image}
                            alt={item.name}
                            className="w-16 h-16 rounded-md object-cover border"
                        />

                        {/* Info */}
                        <div className="flex-1">
                            <p className="text-sm font-medium text-gray-800">
                                {item.name}
                            </p>
                            <p className="text-xs text-gray-500">
                                {formatPrice(item.price)}
                            </p>

                            {/* Quantity */}
                            <div className="flex items-center gap-2 mt-2">
                                <button
                                    onClick={() =>
                                        updateQty(item.id, "dec")
                                    }
                                    className="w-7 h-7 border rounded-md text-sm hover:bg-gray-100"
                                >
                                    −
                                </button>
                                <span className="w-6 text-center text-sm">
                                    {item.quantity}
                                </span>
                                <button
                                    onClick={() =>
                                        updateQty(item.id, "inc")
                                    }
                                    className="w-7 h-7 border rounded-md text-sm hover:bg-gray-100"
                                >
                                    +
                                </button>
                            </div>
                        </div>

                        {/* Total */}
                        <div className="text-right">
                            <p className="text-sm font-semibold text-gray-800">
                                {formatPrice(item.price * item.quantity)}
                            </p>
                            <button
                                onClick={() => removeItem(item.id)}
                                className="text-xs text-red-500 hover:underline mt-1"
                            >
                                Xóa
                            </button>
                        </div>
                    </div>
                ))}
            </div>

            {/* Footer total */}
            <div className="border-t pt-3 flex items-center justify-between">
                <span className="text-sm text-gray-600">
                    Tổng tiền
                </span>
                <span className="text-lg font-bold text-gray-900">
                    {formatPrice(totalPrice)}
                </span>
            </div>
        </div>
    );
};

export default CartProductOrder;
