﻿namespace Infraestructura.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using Dominio.Entidades;
    using Dominio.Repositorio;

    public class MovimientoCuentaCorrienteProveedorRepositorio : Repositorio<MovimientoCuentaCorrienteProveedor> , IMovimientoCuentaCorrienteProveedorRepositorio
    {
        public MovimientoCuentaCorrienteProveedorRepositorio(DataContext context): base(context) { }

        public override MovimientoCuentaCorrienteProveedor Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<MovimientoCuentaCorrienteProveedor>>(_context.Set<Movimiento>().OfType<MovimientoCuentaCorrienteProveedor>(),
                (current, include) => current.Include(include));

            return resultado.FirstOrDefault(x => x.Id == entidadId);
        }

        public override IEnumerable<MovimientoCuentaCorrienteProveedor> Obtener(Expression<Func<MovimientoCuentaCorrienteProveedor, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_context).ObjectContext;

            var resultadoClient = context.CreateObjectSet<Movimiento>().OfType<MovimientoCuentaCorrienteProveedor>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<MovimientoCuentaCorrienteProveedor>>(resultadoClient, (current, include) => current.Include(include));

            if (filtro != null) resultado = resultado.Where(filtro);

            return resultado.ToList();
        }
    }
}
