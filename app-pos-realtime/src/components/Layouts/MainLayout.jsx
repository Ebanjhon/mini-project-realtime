import React from 'react'
import { Link, Outlet, useLocation } from 'react-router-dom'

const MainLayout = () => {
    const location = useLocation();
    return (
        <div className="flex flex-col h-screen">
            <header className="w-full bg-white shadow-md shadow-slate-200">
                <div className="mx-auto px-4">
                    <div className="flex h-16 items-center">

                        <div className="flex flex-1 items-center gap-2">
                            <div className="h-9 w-9 rounded-xl bg-blue-600 flex items-center justify-center text-white font-bold">
                                POS
                            </div>
                            <span className="text-lg font-semibold text-slate-800">
                                Hệ thống bán hàng
                            </span>
                        </div>

                        <nav className="flex flex-1 items-center justify-center gap-8">
                            <Link to="/" className={`${location.pathname === "/" ? "active":"hover:text-slate-800 font-medium"} nav-link`} >Trang chủ</Link>
                            <Link to="/order" className={`${location.pathname === "/order" ? "active":"hover:text-slate-800 font-medium"} nav-link`}>Hóa đơn</Link>
                        </nav>

                        <div className="flex flex-1 items-center justify-end gap-3">
                            <div className="text-right">
                                <p className="text-sm font-semibold text-slate-800">
                                    Nguyễn Văn A
                                </p>
                                <p className="text-xs text-slate-500">
                                    0901 234 567
                                </p>
                            </div>
                            <img
                                src="https://i.pravatar.cc/100"
                                alt="avatar"
                                className="h-10 w-10 rounded-full object-cover border border-slate-200"
                            />
                        </div>

                    </div>
                </div>
            </header>
            <main className="flex-1 flex flex-col overflow-hidden">
                <Outlet />
            </main>
        </div>
    );
}

export default MainLayout