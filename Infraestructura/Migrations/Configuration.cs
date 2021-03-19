﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using static Aplicacion.Constantes.Clases.Password;
using Aplicacion.Constantes;
using Dominio.Entidades;

namespace Infraestructura.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
            try
            {
                // Semilla de Provincias
                if (!context.Provincias.Any())
                {
                    var provincia = new Provincia
                    { Descripcion = @"Tucumán", EstaEliminado = false, Departamentos = new List<Departamento>() };

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Burruyacú",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "7 de Abril (Siete de Abril)", EstaEliminado = false},
                            new Localidad {Descripcion = "Barrio San Jorge", EstaEliminado = false},
                            new Localidad {Descripcion = "El Chañar", EstaEliminado = false},
                            new Localidad {Descripcion = "El Naranjo", EstaEliminado = false},
                            new Localidad {Descripcion = "Garmendia", EstaEliminado = false},
                            new Localidad {Descripcion = "La Ramada", EstaEliminado = false},
                            new Localidad {Descripcion = "Macomitas", EstaEliminado = false},
                            new Localidad {Descripcion = "Piedrabuena", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa Benjamín Aráoz", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa Burruyacú", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa Padre Monti", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Capital",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad
                                {Descripcion = "San Miguel de Tucumán", EstaEliminado = false}
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Chicligasta",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Alpachiri", EstaEliminado = false},
                            new Localidad {Descripcion = "Alto Verde", EstaEliminado = false},
                            new Localidad {Descripcion = "Arcadia", EstaEliminado = false},
                            new Localidad {Descripcion = "Barrio San Roque", EstaEliminado = false},
                            new Localidad {Descripcion = "Concepción", EstaEliminado = false},
                            new Localidad {Descripcion = "Iltico", EstaEliminado = false},
                            new Localidad {Descripcion = "La Trinidad", EstaEliminado = false},
                            new Localidad {Descripcion = "Medinas", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Cruz Alta",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Alderetes", EstaEliminado = false},
                            new Localidad {Descripcion = "Banda del Río Salí", EstaEliminado = false},
                            new Localidad {Descripcion = "Colombres", EstaEliminado = false},
                            new Localidad {Descripcion = "Colonia Mayo", EstaEliminado = false},
                            new Localidad {Descripcion = "Delfín Gallo", EstaEliminado = false},
                            new Localidad {Descripcion = "El Bracho", EstaEliminado = false},
                            new Localidad {Descripcion = "La Florida", EstaEliminado = false},
                            new Localidad {Descripcion = "Las Cejas", EstaEliminado = false},
                            new Localidad {Descripcion = "Los Ralos", EstaEliminado = false},
                            new Localidad {Descripcion = "Pacará", EstaEliminado = false},
                            new Localidad {Descripcion = "Ranchillos", EstaEliminado = false},
                            new Localidad {Descripcion = "San Andrés", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Famaillá",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Barrio Casa Rosada", EstaEliminado = false},
                            new Localidad {Descripcion = "Campo de Herrera", EstaEliminado = false},
                            new Localidad {Descripcion = "Famaillá", EstaEliminado = false},
                            new Localidad {Descripcion = "Ingenio Fronterita", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Graneros",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Graneros", EstaEliminado = false},
                            new Localidad {Descripcion = "Lamadrid", EstaEliminado = false},
                            new Localidad {Descripcion = "Taco Ralo", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Juan Bautista Alberdi",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Juan Bautista Alberdi", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa Belgrano", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "La Cocha",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "La Cocha", EstaEliminado = false},
                            new Localidad {Descripcion = "San Jose de la Cocha", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Leales",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Bella Vista", EstaEliminado = false},
                            new Localidad {Descripcion = "Estación Aráoz", EstaEliminado = false},
                            new Localidad {Descripcion = "Los Puestos", EstaEliminado = false},
                            new Localidad {Descripcion = "Manuel García Fernández", EstaEliminado = false},
                            new Localidad {Descripcion = "Pala Pala", EstaEliminado = false},
                            new Localidad {Descripcion = "Río Colorado", EstaEliminado = false},
                            new Localidad {Descripcion = "Santa Rosa de Leales", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa de Leales", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa Fiad (- Ingenio Leales)", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Lules",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Barrio San Felipe", EstaEliminado = false},
                            new Localidad {Descripcion = "El Manantial", EstaEliminado = false},
                            new Localidad {Descripcion = "Ingenio San Pablo", EstaEliminado = false},
                            new Localidad {Descripcion = "La Reducción", EstaEliminado = false},
                            new Localidad {Descripcion = "Lules", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Monteros",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Acheral", EstaEliminado = false},
                            new Localidad {Descripcion = "Capitán", EstaEliminado = false},
                            new Localidad {Descripcion = "Monteros", EstaEliminado = false},
                            new Localidad
                                {Descripcion = "Pueblo Independencia (Santa Rosa y Los Rojo)", EstaEliminado = false},
                            new Localidad {Descripcion = "Río Seco", EstaEliminado = false},
                            new Localidad {Descripcion = "Santa Lucía", EstaEliminado = false},
                            new Localidad {Descripcion = "Sargento Moya", EstaEliminado = false},
                            new Localidad {Descripcion = "Soldado Maldonado", EstaEliminado = false},
                            new Localidad {Descripcion = "Teniente Berdina", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa Quinteros", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Río Chico",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Aguilares", EstaEliminado = false},
                            new Localidad {Descripcion = "Los Sarmientos", EstaEliminado = false},
                            new Localidad {Descripcion = "Río Chico", EstaEliminado = false},
                            new Localidad {Descripcion = "Santa Ana", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa Clodomiro Hileret", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Simoca",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Atahona", EstaEliminado = false},
                            new Localidad {Descripcion = "Monteagudo", EstaEliminado = false},
                            new Localidad {Descripcion = "Nueva Trinidad", EstaEliminado = false},
                            new Localidad {Descripcion = "Santa Cruz", EstaEliminado = false},
                            new Localidad {Descripcion = "Simoca", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa Chicligasta", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Tafí del Valle",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Amaicha del Valle", EstaEliminado = false},
                            new Localidad {Descripcion = "Colalao del Valle", EstaEliminado = false},
                            new Localidad {Descripcion = "El Mollar", EstaEliminado = false},
                            new Localidad {Descripcion = "Tafí del Valle", EstaEliminado = false}
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Tafí Viejo",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Barrio El Cruce", EstaEliminado = false},
                            new Localidad {Descripcion = "Barrio Lomas de Tafí", EstaEliminado = false},
                            new Localidad {Descripcion = "Barrio Mutual San Martín", EstaEliminado = false},
                            new Localidad {Descripcion = "Barrio Parada 14", EstaEliminado = false},
                            new Localidad {Descripcion = "Barrio U.T.A. II", EstaEliminado = false},
                            new Localidad
                            {
                                Descripcion = "Diagonal Norte (- Luz y Fuerza - Los Pocitos - Villa Nueva Italia)",
                                EstaEliminado = false
                            },
                            new Localidad {Descripcion = "El Cadillal", EstaEliminado = false},
                            new Localidad {Descripcion = "Tafí Viejo", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa Las Flores", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa Mariano Moreno (- El Colmenar)", EstaEliminado = false},
                        }
                    });

                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Trancas",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Choromoro", EstaEliminado = false},
                            new Localidad {Descripcion = "San Pedro de Colalao", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa de Trancas", EstaEliminado = false},
                        }
                    });


                    provincia.Departamentos.Add(new Departamento
                    {
                        Descripcion = "Yerba Buena",
                        EstaEliminado = false,
                        Localidades = new List<Localidad>
                        {
                            new Localidad {Descripcion = "Barrio San José III", EstaEliminado = false},
                            new Localidad {Descripcion = "Villa Carmela (Cebil Redondo)", EstaEliminado = false},
                            new Localidad {Descripcion = "Yerba Buena (- Marcos Paz)", EstaEliminado = false},
                        }
                    });

                    context.Provincias.Add(provincia);

                    context.SaveChanges();
                }

                // ================================================================================================= //
                // ============================     Condicion de Iva      ========================================== //
                // ================================================================================================= //

                if (!context.CondicionIvas.Any())
                {
                    context.CondicionIvas.Add(new CondicionIva
                    { Descripcion = "IVA Responsable No Inscripto", EstaEliminado = false });

                    context.CondicionIvas.Add(new CondicionIva
                    { Descripcion = "IVA Sujeto Exento", EstaEliminado = false });

                    context.CondicionIvas.Add(
                        new CondicionIva { Descripcion = "Consumidor Final", EstaEliminado = false });

                    context.CondicionIvas.Add(new CondicionIva
                    { Descripcion = "Responsable Monotributo", EstaEliminado = false });

                    context.CondicionIvas.Add(new CondicionIva
                    { Descripcion = "Proveedor del Exterior", EstaEliminado = false });

                    context.CondicionIvas.Add(new CondicionIva
                    { Descripcion = "Cliente del Exterior", EstaEliminado = false });

                    context.CondicionIvas.Add(new CondicionIva
                    { Descripcion = "IVA Liberado - Ley 19.640", EstaEliminado = false });

                    context.CondicionIvas.Add(new CondicionIva
                    { Descripcion = "Monotributista Social", EstaEliminado = false });

                    context.CondicionIvas.Add(
                        new CondicionIva { Descripcion = "IVA No Alcanzado", EstaEliminado = false });

                    context.SaveChanges();

                }

                // ================================================================================================= //
                // ============================        Cliente Por Defecto    ====================================== //
                // ================================================================================================= //

                if (!context.Personas.OfType<Cliente>().Any(x => x.Dni == "99999999"))
                {
                    var localidadPorDefecto = context.Localidades.AsNoTracking().FirstOrDefault(x => x.Descripcion == "San Miguel de Tucumán");

                    var condicionIvaPorDefecto = context.CondicionIvas.AsNoTracking().FirstOrDefault(x => x.Descripcion == "Consumidor Final");

                    var ClienteConsumidorFinal = new Cliente
                    {
                        LocalidadId = localidadPorDefecto.Id,
                        CondicionIvaId = condicionIvaPorDefecto.Id,
                        Apellido = "Consumidor",
                        Nombre = "Final",
                        Dni = "99999999",
                        EstaEliminado = false,
                        ActivarCtaCte = false,
                        Direccion = "No Declarada",
                        Mail = "consumidorFinal@gmail.com",
                        MontoMaximoCtaCte = 0m,
                        TieneLimiteCompra = false,
                        Telefono = "0123456789"
                    };

                    context.Personas.Add(ClienteConsumidorFinal);

                    context.SaveChanges();
                }

                //
                // Contadores por Defecto
                //
                if (!context.Contadores.Any())
                {
                    context.Contadores.Add(
                        new Contador { 
                            EstaEliminado = false,
                            Valor = 0,
                            TipoComprobante = TipoComprobante.A
                        }
                        );
                    context.Contadores.Add(
                        new Contador { 
                            EstaEliminado = false,
                            Valor = 0,
                            TipoComprobante = TipoComprobante.B
                        }
                        );
                    context.Contadores.Add(
                        new Contador { 
                            EstaEliminado = false,
                            Valor = 0,
                            TipoComprobante = TipoComprobante.C
                        }
                        );
                    context.Contadores.Add(
                        new Contador { 
                            EstaEliminado = false,
                            Valor = 0,
                            TipoComprobante = TipoComprobante.NotaCredito
                        }
                        );
                    context.Contadores.Add(
                        new Contador { 
                            EstaEliminado = false,
                            Valor = 0,
                            TipoComprobante = TipoComprobante.Presupuesto
                        }
                        );
                    context.Contadores.Add(
                        new Contador { 
                            EstaEliminado = false,
                            Valor = 0,
                            TipoComprobante = TipoComprobante.Remito
                        }
                        );
                }

                //
                // Puesto Trabajo
                //
                if (!context.Tarjetas.Any())
                    context.Tarjetas.Add(new Tarjeta { 
                        Descripcion = "Latarjeta",
                    });

                //
                // Puesto Trabajo
                //
                if (!context.Bancos.Any())
                    context.Bancos.Add(new Banco { 
                        Descripcion = "Bank Ito",
                    });

                //
                // Puesto Trabajo
                //
                if (!context.PuestoTrabajos.Any())
                    context.PuestoTrabajos.Add(new PuestoTrabajo { 
                        Codigo = 1,
                        Descripcion = "Puesto01",
                    });

                //
                // Unidad
                //
                if (!context.UnidadMedidas.Any())
                    context.UnidadMedidas.Add(new UnidadMedida { 
                        Descripcion = "Unidades",
                    });

                //
                // Marca
                //
                if (!context.Marcas.Any())
                    context.Marcas.Add(new Marca { 
                        Descripcion = "Generica",
                    });

                //
                // Lista Precios
                //
                if (!context.ListaPrecios.Any())
                    context.ListaPrecios.Add(new ListaPrecio { 
                        Descripcion = "Contado",
                        PorcentajeGanancia = 1,
                        NecesitaAutorizacion = false
                    });

                //
                // Rubro
                //
                if (!context.Rubros.Any())
                    context.Rubros.Add(new Rubro { 
                        Descripcion = "General"
                    });

                //
                // Deposito
                //
                if (!context.Depositos.Any())
                    context.Depositos.Add(new Deposito { 
                        Descripcion = "Principal",
                        Ubicacion = "Principal"
                    });

                //
                // Usuario Administrador
                //
                if (!context.Empleados.Any())
                    context.Empleados.Add(new Empleado
                    {
                        Legajo = 1,
                        Apellido = "Administrador",
                        Nombre = "Usuario",
                        Dni = "00000000",
                        Direccion = "Sin direccion",
                        Mail = "sin@correo.com",
                        Telefono = "0000000000",
                        Foto = Imagen.ConvertirImagen(Imagen.ImagenEmpleadoPorDefecto),
                        LocalidadId = 1,
                        EstaEliminado = false
                    });

                if (!context.Usuarios.Any() && !context.Empleados.Any())
                {
                    var empleAdmin = context.Empleados.FirstOrDefault(x => x.Dni == "0");
                
                    if (empleAdmin != null)
                        context.Usuarios.Add(new Usuario
                        {
                            EmpleadoId = empleAdmin.Id,
                            Nombre = "admin",
                            Password = Encriptar("123"),
                            EstaBloqueado = false,
                            EstaEliminado = false,
                        });
                }

                //
                // Configuracion Inicial
                //
                //if (!context.Configurationes.Any())
                //{
                //    context.Configurationes.Add(new Configuracion
                //    {
                //        EstaEliminado = false,
                //        LocalidadId = context.Localidades.First().Id,
                //        DepositoNuevoArticuloId = context.Depositos.First().Id,
                //        DepositoVentaId = context.Depositos.First().Id,
                //        ListaPrecioPorDefectoId = context.ListaPrecios.First().Id,
                //        RazonSocial = "Razón Social",
                //        NombreFantasia = "Fantasía",
                //        Telefono = "0000000000",
                //        Celular = "0000000000",
                //        Cuit = "00000000000",
                //        Direccion = "Sin dirección",
                //        Email =  "sin@mail.com",
                //        ObservacionEnPieFactura = "",
                //        ActivarRetiroDeCaja = false,
                //        ActualizaCostoDesdeCompra = true,
                //        FacturaDescuentaStock = true,
                //        IngresoManualCajaInicial = true,
                //        ModificaPrecioVentaDesdeCompra = false,
                //        MontoMaximoRetiroCaja = 0,
                //        PresupuestoDescuentaStock = false,
                //        PuestoCajaSeparado = false,
                //        RemitoDescuentaStock = false,
                //        TipoFormaPagoPorDefectoCompra = TipoPago.Efectivo,
                //        TipoFormaPagoPorDefectoVenta = TipoPago.Efectivo,
                //        UnificarRenglonesIngresarMismoProducto = true,
                //        ActivarBascula = true,
                //        CodigoBascula = "4004",
                //        EtiquetaPorPeso = true,
                //        EtiquetaPorPrecio = false,
                //    });
                //}
            }
            catch (Exception e)
            {
                throw new Exception($"Ocurrio un Error en el Seed - {e.Message}");
            }
        }
    }
}
