"use client";
// Core
import { useQuery } from "@tanstack/react-query";
import { useMemo } from "react";

// Components
import { Box, Card, CardContent, CardMedia, Typography } from "@mui/material";
import { Loader } from "@/shared/components/loader/loader";

// Hooks
import { usePropertiesContext } from "../../context/use-properties-context.hook";
import { useLanguage } from "@/shared/hooks/use-language.hook";

// Services
import { getProperties } from "@/shared/services/properties.service";

// Utils
import { t } from "@/shared/utils/translate.util";
import { formatNumberToMoney } from "@/shared/utils/formatter-options.util";

// Interfaces
import { Properties } from "@/shared/interfaces/properties.interfaces";
import { useNavigate } from "@/shared/hooks/use-navigate.hook";

export const Items: React.FC = () => {
  const language = useLanguage();
  const { navigate } = useNavigate();
  const { rent, sell, noData } = t(language).properties.items;
  const { state } = usePropertiesContext();

  const { data, isLoading } = useQuery({
    queryKey: ["properties", state.filters.type, state.filters.search],
    queryFn: () => getProperties(state.filters),
  })

  const cards = useMemo(() => {
    return data?.data ?? [];
  }, [data])

  const handleClick = (id: string) => {
    navigate(`/properties/${id}`);
  }

  if (isLoading) return <Loader />;

  return (
    <section className="w-full max-w-7xl mx-auto px-4 py-8">
      {cards.length === 0 ? (
        <div className="text-center py-16">
          <Typography variant="h6" color="text.secondary">
            {noData}
          </Typography>
        </div>
      ) : (
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
          {cards.map((property: Properties) => (
            <Card
              key={property.id}
              className="relative shadow-md rounded-xl overflow-hidden cursor-pointer hover:shadow-lg transition"
              onClick={() => handleClick(property.id)}
            >
              <Box
                sx={{
                  position: "absolute",
                  top: 12,
                  left: 12,
                  backgroundColor: property.type === "rent" ? "orange" : "green",
                  color: "white",
                  fontSize: "0.75rem",
                  fontWeight: "bold",
                  px: 1.5,
                  py: 0.5,
                  borderRadius: "8px",
                  zIndex: 10,
                }}
              >
                {property.type === "rent" ? rent : sell}
              </Box>
              <CardMedia
                component="img"
                height="180"
                image={property.images[0] || "/images/default-property.jpg"}
                alt={property.name}
              />
              <CardContent>
                <Typography variant="h6" className="font-semibold">
                  {property.name}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  {property.addressProperty}
                </Typography>
                <Typography
                  variant="subtitle1"
                  className="mt-2 font-bold text-blue-600"
                >
                  ${formatNumberToMoney(property.priceProperty)}
                </Typography>
              </CardContent>
            </Card>
          ))}
        </div>
      )}
    </section>
  );
};