export const formatPrice = (value) => {
  return value.toLocaleString("vi-VN") + " VNĐ";
};


export const formatDateTime = (dateString) => {
  if (!dateString || dateString === "0001-01-01T00:00:00") return "";

  const date = new Date(dateString);

  const formatter = new Intl.DateTimeFormat("en-GB", {
    timeZone: "Asia/Ho_Chi_Minh",
    day: "2-digit",
    month: "2-digit",
    year: "numeric",
    hour: "numeric",
    minute: "2-digit",
    hour12: true,
  });

  const parts = formatter.formatToParts(date);

  const day = parts.find(p => p.type === "day").value;
  const month = parts.find(p => p.type === "month").value;
  const year = parts.find(p => p.type === "year").value;
  const hour = parts.find(p => p.type === "hour").value;
  const minute = parts.find(p => p.type === "minute").value;
  const ampm = parts.find(p => p.type === "dayPeriod").value.toUpperCase();

  return `${day}/${month}/${year} - ${hour}:${minute} ${ampm}`;
};

