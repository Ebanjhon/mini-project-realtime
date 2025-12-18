import React, { useEffect, useRef, useState } from 'react'
import CartProduct from '../../components/CartProduct/CartProduct';
import ProductFilter from '../../components/ProductFilter/ProductFilter';
import axios from 'axios';
import OrderDetail from './OrderDetail/OrderDetail';
import { API_HOST } from '../../configs';

const Home = () => {
  const orderDetailRef = useRef();
  const [products, setProducts] = useState([]);

  const handleAddToCart = (product) => {
    console.log("Thêm vào giỏ:", product);
  }

  const fetchProducts = async (categoryId, textSearch) => {
    try {
      const res = await axios.get(`${API_HOST}/Product/GetProductList`, {
        params: { categoryId, textSearch }
      });
      setProducts(res.data.data);
    } catch (error) {
      console.error("Error fetching products:", error);
    }
  };

  useEffect(() => {
    fetchProducts();
  }, []);

  return (
    <div className="flex h-full">
      <div className="flex-1 flex flex-col overflow-hidden h-full">
        <div className="w-full flex items-center px-3 flex-shrink-0" style={{ height: '55px' }}>
          <ProductFilter handleFetchProduct={fetchProducts} />
        </div>
        <div className="flex-1 overflow-y-auto p-2 grid grid-cols-4 gap-4">
          {products.map((item) => (
            <CartProduct key={item.id} product={item} onAddToCart={()=>orderDetailRef.current.setOrderFromParent(item)} />
          ))}
        </div>
      </div>

      <div className="w-[25%] border border-slate-200 shadow-[-6px_0_12px_rgba(0,0,0,0.06)] p-2 flex flex-col h-full">
        <OrderDetail ref={orderDetailRef}/>
      </div>
    </div>
  );
}

export default Home