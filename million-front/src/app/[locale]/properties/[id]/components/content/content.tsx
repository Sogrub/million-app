"use client";
// Core
import { useQuery } from "@tanstack/react-query";
import { useParams } from "next/navigation";
import Image from "next/image";

// Components
import {
  Box,
  Typography,
  Card,
  CardContent,
  Avatar,
  Grid,
} from "@mui/material";
import { Loader } from "@/shared/components/loader/loader";

// Services
import { getPropertyById } from "@/shared/services/properties.service";

// Hooks
import { useLanguage } from "@/shared/hooks/use-language.hook";

// Utils
import { t } from "@/shared/utils/translate.util";
import { formatNumberToMoney } from "@/shared/utils/formatter-options.util";

// Interfaces
import { PropertyImage } from "@/shared/interfaces/properties.interfaces";

export const Content: React.FC = () => {
  const language = useLanguage();
  const { noData, address, birthDate, galleryTitle } = t(language).properties.content;
  const { id } = useParams<{ id: string }>();

  const { data, isLoading } = useQuery({
    queryKey: ["property", id],
    queryFn: () => getPropertyById(id),
    enabled: !!id,
  });

  if (isLoading) return <Loader />;

  const property = data?.data;

  if (!property) {
    return (
      <Box className="text-center py-16">
        <Typography variant="h6" color="text.secondary">
          {noData}
        </Typography>
      </Box>
    );
  }

  return (
    <section className="w-full max-w-6xl mx-auto px-4 py-10">
      <Box className="relative w-full h-[450px] rounded-2xl overflow-hidden shadow-lg mb-8">
        <Image
          src={property.images[0]?.image || "/images/default-property-detail.jpg"}
          fill
          alt={property.name}
          className="object-cover"
          priority
        />
        <Box className="absolute bottom-0 left-0 w-full bg-gradient-to-t from-black/70 to-transparent p-6">
          <Typography variant="h4" className="font-bold text-white">
            {property.name}
          </Typography>
          <Typography variant="h6" className="text-gray-200">
            {property.addressProperty}
          </Typography>
        </Box>
      </Box>

      <div className="flex flex-col gap-8">
        <div className="flex flex-col gap-4 flex-1">
          <Typography variant="h5" color="primary" className="font-bold mb-4">
            ${formatNumberToMoney(property.priceProperty)}
          </Typography>

          <Card className="shadow-md rounded-xl mb-6">
            <CardContent className="flex items-center gap-4">
              <Avatar
                src={property.owner.photo}
                alt={property.owner.name}
                sx={{ width: 70, height: 70 }}
              />
              <Box>
                <Typography variant="h6">{property.owner.name}</Typography>
                <Typography variant="body2" color="text.secondary">
                  {address}: {property.owner.address}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  {birthDate}: {property.owner.birthDate}
                </Typography>
              </Box>
            </CardContent>
          </Card>

          <Typography variant="body1" className="leading-relaxed text-gray-700">
            {property.description}
          </Typography>
        </div>

        <div className="flex flex-col gap-4 flex-1">
          <Card className="shadow-md rounded-xl">
            <CardContent className="flex flex-col gap-4">
              <Typography variant="h6" className="mb-4">
                {galleryTitle}
              </Typography>
              <Grid container spacing={2}>
                {property.images.map((img: PropertyImage) => (
                  <Box className="relative w-36 h-28 rounded-lg overflow-hidden shadow-sm" key={img.id}>
                    <Image
                      src={img.image}
                      alt="Imagen propiedad"
                      fill
                      className="object-cover"
                      priority
                    />
                  </Box>
                ))}
              </Grid>
            </CardContent>
          </Card>
        </div>
      </div>
    </section>
  );
};
