import React from 'react'
import { Link } from 'react-router-dom'

const Order = () => {
    return (
        <div className="flex h-screen">
            {/* Cột trái - scroll */}
            <div className="flex-1 flex flex-col overflow-hidden border-r border-slate-200">
                {/* Header nhỏ, cố định trên cùng nếu muốn */}
                <div className="h-16 flex-shrink-0 flex items-center px-4 border-b bg-white">
                    Thanh Select / Header
                </div>

                {/* Container scroll */}
                <div className="flex-1 overflow-y-auto p-4 bg-red-50">
                    {Array.from({ length: 50 }).map((_, i) => (
                        <div key={i} className="p-2 mb-2 border rounded bg-white">
                            Item {i + 1}
                        </div>
                    ))}
                </div>
            </div>

            <div className="w-[25%] p-4 border-l border-slate-200 bg-gray-100 flex-shrink-0">
                Nội dung cố định (không cuộn)
            </div>
        </div>
    )
}

export default Order